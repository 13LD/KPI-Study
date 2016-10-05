from lxml import etree

tree = etree.parse("data.xml")
page_cnt = tree.xpath("count(/data/page)")



averege_counter = 0

for i in range(int(page_cnt)):
    cnt = tree.xpath("count(//page[{}]/fragment[@type='text'])".format(i + 1))
    averege_counter += cnt
    print cnt


print averege_counter / int(page_cnt)
