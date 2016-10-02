from lxml import etree
from lxml.html.clean import clean_html
import urllib2



def get_text(text):
    text = map(lambda x: ' '.join(x.split()), text)
    text = filter(lambda x: len(x) > 2, text) 
    return text


def get_images(images):
    return map(lambda img: img if img.startswith("http") else 'http://www.xsport.ua' + img, images)


def get_urls(urls):
    urls = list(set(urls))
    urls = filter(lambda x: len(x) > 3 and x[0] == "/", urls)
    urls = map(lambda x: 'http://www.xsport.ua' + x, urls)
    return urls


def parse_html(url):
    response = urllib2.urlopen(url)

    page = response.read()
    page = clean_html(page)

    tree = etree.HTML(page.decode('utf-8'))

    text = tree.xpath('//text()')
    text = get_text(text)

    images = tree.xpath('//img/@src')
    images = get_images(images)

    urls = tree.xpath('//a/@href')
    urls = get_urls(urls)

    return urls, text, images


def create_xml_page(page_url, text, images):
    page_elem = etree.Element("page", url=page_url)

    for elem in text:
        fragment = etree.Element("fragment", type="text")
        fragment.text = elem
        page_elem.append(fragment)

    for img in images:
        fragment = etree.Element("fragment", type="image")
        fragment.text = img
        page_elem.append(fragment)

    return page_elem


def create_xml(filename):
    root = etree.Element("data")

    urls, _, _ = parse_html('http://www.xsport.ua')
    urls.insert(0, 'http://www.xsport.ua')


    for url in urls[-20:]:
        _, text, images = parse_html(url)
        page_elem = create_xml_page(url, text, images)
        root.append(page_elem)

    et = etree.ElementTree(root)
    et.write(filename, xml_declaration=True, encoding="utf-8", pretty_print=True)


create_xml("data.xml")