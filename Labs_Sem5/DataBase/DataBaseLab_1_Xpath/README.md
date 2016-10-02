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
##Task 2
By means of XPath find all urls

```Python
from lxml import etree

tree = etree.parse("data.xml")
cnt = tree.xpath('//page/@url')

for i in cnt:
    print i

```

##Task 3
Analyze a content of Web store and fetch price, name, description and image of 20 products from that site. Use XPath and DOM-parser to find appropriate nodes.

```Python
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
```


##Task 4
By means of XSLT language, convert obtained XML-file to XHTML page

```Python
xslt_root = etree.parse("pattern.xsl")
transorm = etree.XSLT(xslt_root)
xml_root = etree.parse("products.xml")
result_tree = transorm(xml_root)
result = str(result_tree)
with open("products.xhtml", "w") as out:
    out.write(result)
```

<b>pattern.xsl</b>
```XSL
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <body>
  <h2>Products</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th style="text-align:left">Name</th>
        <th style="text-align:left">Price</th>
        <th style="text-align:left">Description</th>
        <th style="text-align:left">Image url</th>
      </tr>
      <xsl:for-each select="data/product">
      <tr>
        <td><xsl:value-of select="name"/></td>
        <td><xsl:value-of select="price"/></td>
        <td><xsl:value-of select="description"/></td>
        <td><xsl:value-of select="image"/></td>
      </tr>
      </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>
```
##Result of task4
```HTML
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
</head>
<body>
<h2>Products</h2>
<table border="1">
    <tr bgcolor="#0000FF">
        <th style="text-align:left">Name</th>
        <th style="text-align:left">Price</th>
        <th style="text-align:left">Description</th>
        <th style="text-align:left">Image url</th>
    </tr>
    <tr>
        <td>Диван Лукас-12 </td>
        <td>3545 грн</td>
        <td>Код товара: 5462
            Размеры (мм): 1900х850x960																	</td>
            <td>http://www.meblium.com.ua/images/product/d/i/min/w_meblium_240_240-divan_lukas_neo_late_neo_shokolad1_204e06c78504227fe13dd88c543e884d.jpg
            </td>
    </tr>
    <tr>
        <td>Диван Лукас-12 </td>
        <td>3545 грн</td>
        <td>Код товара: 5462
            Размеры (мм): 1900х850x960																	</td>
            <td>http://www.meblium.com.ua/images/product/d/i/min/w_meblium_240_240-divan_lukas_neo_late_neo_shokolad1_204e06c78504227fe13dd88c543e884d.jpg</td>
        </tr>
        ...
</table>
</body>
</html>

```
