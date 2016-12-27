from neo4jrestclient.client import GraphDatabase
from neo4jrestclient import client


class DB(object):
	def __init__(self):
		self.db = GraphDatabase("http://localhost:7474", username='neo4j', password='1111')

	def fill_db(self):
		user = self.db.labels.create("User")
		u1 = self.db.nodes.create(name="Sasha")
		user.add(u1)
		u2 = self.db.nodes.create(name="Dima")
		user.add(u2)
		u3 = self.db.nodes.create(name="Max")
		user.add(u3)

		hobby = self.db.labels.create("Hobby")
		h1 = self.db.nodes.create(name="Coding")
		hobby.add(h1)
		h2 = self.db.nodes.create(name="Reading")
		hobby.add(h2)

		u1.relationships.create("has_hobby_such_as", h1)
		u1.relationships.create("has_hobby_such_as", h2)
		u2.relationships.create("has_hobby_such_as", h1)
		u3.relationships.create("has_hobby_such_as", h2)

	def insert_new_user(self, name):
		user = self.db.labels.get("User")
		u = self.db.node.create(name=name)
		user.add(u)

	def insert_new_hobby(self, hobby):
		hobby = self.db.labels.get("Hobby")
		h = self.db.node.create(name=hobby)
		hobby.add(h)

	def make_relationship(self, name, hobby):
		q = 'MATCH(u:User) WHERE u.name="' + name + '" RETURN u'
		user = self.db.query(q, returns=(client.Node))[0][0]

		q = 'MATCH(h:Hobby) WHERE h.name="' + hobby + '" RETURN h'
		hobby = self.db.query(q, returns=(client.Node))[0][0]

		user.relationships.create("has_hobby_such_as", hobby)



	def show_common_hobbies(self, u1, u2):
		q = 'MATCH(u1:User)-[:has_hobby_such_as]->(h:Hobby)<-[:has_hobby_such_as]-(u2:User)' \
		    ' WHERE u1.name="'+ u1 + \
		    '" AND u2.name="'+ u2 +'" RETURN h.name AS hobby'

		results = self.db.query(q, returns=(str))
		if results:
			print(u1 + ' and ' + u2 + ' have such common hobbies: ')
			for r in results:
				print(r[0])

	def show_users_without_hobbies(self):
		q = 'MATCH(u:User) WHERE NOT (u)-[:has_hobby_such_as]-()' \
		    'RETURN u.name AS name'

		results = self.db.query(q, returns=(str))
		for r in results:
			print(r[0] + ' doesn\'t have any hobby!')


db = DB()
# db.fill_db()
db.show_common_hobbies('Sasha', 'Dima')