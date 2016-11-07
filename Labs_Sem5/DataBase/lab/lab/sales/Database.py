from xml.dom import minidom
import sys
from pymongo import MongoClient
from bson.objectid import ObjectId
from bson.code import Code
from bson.son import SON
import time
from models import User, Product, Department, Sale, userFromDict, productFromDict, departmentFromDict


class DB(object):
    def __init__(self):
        self.client = MongoClient('mongodb://127.0.0.1:27017/')
        self.db = self.client.bdlab2
        self.users = self.db.users
        self.products = self.db.products
        self.departments = self.db.departments
        self.sales = self.db.sales

    def initial(self):
        u = User("Sasha", "Chepurnoi", 20)
        u2 = User("Erik", "Gimiranov", 18)
        u3 = User("Dima", "Lysogor", 27)

        p = Product("Bread", 1000)
        p2 = Product("Water", 4000)
        p3 = Product("Chocolate", 500)

        d = Department("Food store 1", "Street 1")
        d2 = Department("Food store 2", "Street 2")
        d3 = Department("Food store 3", "Street 3")
        self.users.insert(u.mongify())
        self.users.insert(u2.mongify())
        self.users.insert(u3.mongify())

        self.products.insert(p.mongify())
        self.products.insert(p2.mongify())
        self.products.insert(p3.mongify())

        self.departments.insert(d.mongify())
        self.departments.insert(d2.mongify())
        self.departments.insert(d3.mongify())

    def getSaleById(self, id):
        sale = self.sales.find_one({"_id": ObjectId(id)})
        return sale

    def getProductById(self, id):
        productDict = self.products.find_one({"_id": ObjectId(id)})
        return productFromDict(productDict)

    def getUserById(self, id):
        userDict = self.users.find_one({"_id": ObjectId(id)})
        return userFromDict(userDict)

    def getDepartmentById(self, id):
        departmentDict = self.departments.find_one({"_id": ObjectId(id)})
        return departmentFromDict(departmentDict)

    def deleteSaleById(self, id):
        self.sales.delete_one({'_id': ObjectId(id)})

    def countSalesSum(self):
        map = Code("""
        				   function(){
        					  var price = this.product.price;
        					  emit('sum',price);
        		           };
        		           """)

        reduce = Code("""
        					  function(key, vals){
        						return Array.sum(vals);
        		              };
        		              """)
        results = self.db.sales.map_reduce(map, reduce, "results_")
        res = results.find_one()['value']
        return res


    def avgAgeOfUsers(self):
        map = Code("""
            				   function(){
            					  emit('age', this.age);
            		           };
            		           """)

        reduce = Code("""
            					  function(key, vals){
            						return Array.sum(vals) / vals.length;
            		              };
            		              """)
        results = self.db.users.map_reduce(map, reduce, "results_")
        res = results.find_one()['value']
        return res

    def analyzeOrders(self):
        pipeline = [
            {"$group": {"_id": "$user.name", "count": {"$sum": 1}}},
            {"$sort": SON([("count", -1)])}
        ]
        res = list(self.db.sales.aggregate(pipeline))[0]
        return res