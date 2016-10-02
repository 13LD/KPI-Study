from lxml import etree

tree = etree.parse("data.xml")
cnt = tree.xpath('//page/@url')

for i in cnt:
    print i


