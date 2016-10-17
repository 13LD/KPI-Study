
from xml.dom import minidom
from pymongo import MongoClient
from bson.objectid import ObjectId
from bson.code import Code
from bson.son import SON
from models import Sales, Shop, User, Product


class DB(object):
    def __init__(self):
        self.client = MongoClient()
        self.db = self.client.bdlab2
        self.users = self.db.users
        self.products = self.db.products
        self.shops = self.db.shops
        self.sales = self.db.sales

    def __data__(self):
        u = User("Sasha", "Chepurnoi", 20)
        u2 = User("Erik", "Gimiranov", 18)
        u3 = User("Dima", "Lysogor", 27)

        p = Product("Bread", 1000)
        p2 = Product("Water", 4000)
        p3 = Product("Chocolate", 500)

        d = Shop("Food store 1", "Street 1")
        d2 = Shop("Food store 2", "Street 2")
        d3 = Shop("Food store 3", "Street 3")
        self.users.insert(u.mongify())
        self.users.insert(u2.mongify())
        self.users.insert(u3.mongify())

        self.products.insert(p.mongify())
        self.products.insert(p2.mongify())
        self.products.insert(p3.mongify())

        self.shops.insert(d.mongify())
        self.shops.insert(d2.mongify())
        self.shops.insert(d3.mongify())
