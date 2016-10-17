from __future__ import unicode_literals

from xml.dom import minidom

from django.db import models
from django.db.models import Manager


class ProductManager(models.Manager):
    def initialize(self,):
        self.model.objects.all().delete()
        from django.db import connection
        cursor = connection.cursor()
        cursor.execute("ALTER TABLE polls_product AUTO_INCREMENT = 1")
        xmldoc = minidom.parse('tables.xml')
        product_list = xmldoc.getElementsByTagName('product')
        for product in product_list:
            productName = str(product.getElementsByTagName('productName')[0].firstChild.data)
            productPrice = int(product.getElementsByTagName('productPrice')[0].firstChild.data)
            self.model.objects.create(productName=productName, productPrice=productPrice)


class UserManager(models.Manager):
    def initialize(self,):
        self.model.objects.all().delete()
        from django.db import connection
        cursor = connection.cursor()
        cursor.execute("ALTER TABLE polls_user AUTO_INCREMENT = 1")
        xmldoc = minidom.parse('tables.xml')
        product_list = xmldoc.getElementsByTagName('user')
        for product in product_list:
            userName = str(product.getElementsByTagName('userName')[0].firstChild.data)
            userSurname = str(product.getElementsByTagName('userSurname')[0].firstChild.data)
            userAge = int(product.getElementsByTagName('userAge')[0].firstChild.data)
            self.model.objects.create(userName=userName, userSurname=userSurname, userAge=userAge)



class ShopManager(models.Manager):
    def initialize(self,):
        self.model.objects.all().delete()
        from django.db import connection
        cursor = connection.cursor()
        cursor.execute("ALTER TABLE polls_shop AUTO_INCREMENT = 1")
        xmldoc = minidom.parse('tables.xml')
        shop_list = xmldoc.getElementsByTagName('shop')
        for product in shop_list:
            shopName = str(product.getElementsByTagName('shopName')[0].firstChild.data)
            shopAdd = str(product.getElementsByTagName('shopAddress')[0].firstChild.data)
            self.model.objects.create(shopName=shopName, shopAddress=shopAdd)





class User(models.Model):
    userName = models.CharField(max_length=50)
    userSurname = models.CharField(max_length=50)
    userAge = models.IntegerField()
    objects = UserManager()


class Shop(models.Model):
    shopName = models.CharField(max_length=50)
    shopAddress = models.CharField(max_length=50)
    objects = ShopManager()


class Product(models.Model):
    productName = models.CharField(max_length=50)
    productPrice = models.IntegerField()
    objects = ProductManager()



class Sales(models.Model):
    user = models.ForeignKey(User)
    shop = models.ForeignKey(Shop)
    product = models.ForeignKey(Product)
    saleType = models.CharField(max_length=50)
    saleDate = models.CharField(max_length=50)
    objects = Manager()