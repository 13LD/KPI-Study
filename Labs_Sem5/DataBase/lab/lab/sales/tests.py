from django.test import TestCase

# Create your tests here.
from Database import DB

database = DB()
database.initial()
res = database.analyzeOrders()
print res