#Lab 2


#Map reduce:
Counts total sum of all sales. 
Counts average age of all customers.

```

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
        
```

#Aggregate:

Get top customer.

```

 def analyzeOrders(self):
        pipeline = [
            {"$group": {"_id": "$user.name", "count": {"$sum": 1}}},
            {"$sort": SON([("count", -1)])}
        ]
        res = list(self.db.sales.aggregate(pipeline))[0]
        return res

```

#Common functions 

```

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

```