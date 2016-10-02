# DataBaseLab1
Python lab  which helps to parse information from html and store it in xml file

##Task 1
* Obtaining text and graphic information from HTML tags of this site pages by XPATH.
```Python
def parse_html(url):
    response = urllib2.urlopen(url)
    page = response.read()

    tree = etree.HTML(page.decode('utf-8'))

    text = tree.xpath('//text()')
    text = get_text(text)

    images = tree.xpath('//img/@src')
    images = get_images(images)

    urls = tree.xpath('//a/@href')
    urls = get_urls(urls)

    return urls, text, images
```


* Store parsed information in XML file

```Python
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
```
