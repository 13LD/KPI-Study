from pymongo import MongoClient
from bson.son import SON


class DB(object):

	def __init__(self):
		self.client = MongoClient('127.0.0.1', 27017)
		self.db = self.client.newdb

	def insert_document(self, collection, url, *ips):
		doc = {}
		doc['url'] = url
		doc['visits'] = []
		for ip in ips:
			ip_object = {}
			ip_object['ip'] = ip[0]
			ip_object['date'] = ip[1]
			doc['visits'].append(ip_object)
		self.db[collection].insert(doc)

	def most_common_ips(self, count_of_ips):
		pipeline = [
			{"$unwind": "$visits"},
			{"$group": {"_id": "$visits.ip", "count": {"$sum": 1}}},
			{"$sort": SON([("count", -1)])},
			{"$limit": count_of_ips}
		]
		print list(self.db.collection.aggregate(pipeline))


	def list_of_ips_that_visit_all_urls(self):
		print self.db.collection.count()
		pipeline = [
			{"$unwind": "$visits"},
			{"$group": {"_id": {
							"url": "$url",
							"ip": "$visits.ip"
								},
						"count": {"$sum": 1}
						}
			},
			{"$group": {"_id": "$_id.ip", "count": {"$sum": 1}}},
			{"$match": {"count": self.db.collection.count()}}
		]
		print list(self.db.collection.aggregate(pipeline))


	def count_of_visits_by_date(self):
		pipeline = [
			{"$unwind": "$visits"},
			{"$group": {"_id": {
							"url": "$url",
			                "date": "$visits.date"
			                    } ,
						"count": {"$sum": 1}
						}
			},
			{"$sort": SON([("_id", -1)])}
		]
		print list(self.db.collection.aggregate(pipeline))

db = DB()
# db.insert_document('collection', 'ukr.net', ('1.1.1.1', '27/12/2016'), ('1.2.1.1', '27/12/2016'))
# db.most_common_ips(2)
# db.list_of_ips_that_visit_all_urls()
# db.count_of_visits_by_date()