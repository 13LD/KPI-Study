from lxml import etree
import urllib2
from task1 import get_text

BASE_URL = "http://www.meblium.com.ua/myagkaya-mebel/divany"


class Product:
    def __init__(self, name, price, description, image):
        self.name = name
        self.price = price
        self.description = description
        self.image = image

    def __str__(self):
        return self.name.encode('utf-8')

    def __repr__(self):
        return self.name.encode('utf-8')


def parse_html(url):
    response = urllib2.urlopen(BASE_URL + url)
    page = response.read()

    tree = etree.HTML(page)

    name = tree.xpath("string(//span[@class='product-name']/text())")
    price = tree.xpath("string(//span[@class='old-price']/text())")
    image = tree.xpath("string(//img[@itemprop='image']/@src)")
    desc1 = tree.xpath("string(//span[@class='product-model']//text())")
    desc2 = tree.xpath("string(//span[@itemprop='model']//text())")
    desc3 = tree.xpath("string(//span[@class='product-model'][2]//text())")

    desc = desc1 + desc2 + desc3



    return Product(name, price, desc, image)


def generate_xml(filename):
    response = urllib2.urlopen(BASE_URL)
    page = response.read()

    tree = etree.HTML(page)

    urls = tree.xpath('//a/@href')
    urls = list(set(urls))
    urls = filter(lambda x: x.startswith('http://www.meblium.com.ua/divan'), urls)

    products = []
    for url in urls:
        products.append(parse_html(url))

    root = etree.Element("data")

    for product in products:
        product_el = etree.Element("product")

        name_el = etree.Element("name")
        name_el.text = product.name

        price_el = etree.Element("price")
        price_el.text = product.price

        desc_el = etree.Element("description")
        desc_el.text = product.description

        image_el = etree.Element("image")
        image_el.text = product.image

        product_el.append(name_el)
        product_el.append(price_el)
        product_el.append(desc_el)
        product_el.append(image_el)

        root.append(product_el)

    et = etree.ElementTree(root)
    et.write(filename, encoding="utf-8", xml_declaration=True, pretty_print=True)

generate_xml("products.xml")