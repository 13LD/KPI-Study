from django.shortcuts import render

# Create your views here.

from django import template
from django.core.urlresolvers import reverse
from django.http import HttpResponse
from bson.objectid import ObjectId
from django.shortcuts import render, redirect
from Database import DB
from models import User, Product, Shop, Sales, userFromDict, productFromDict, departmentFromDict

# Create your views here.

database = DB()


def index(request):
    # avgUsers = database.avgAgeOfUsers()
    # salesSum = database.countSalesSum()
    # topUser = database.analyzeOrders()
    return render(request, 'adminpage.html',
                  {'message': request.GET.get('message', None), 'avgAge': avgUsers, 'salesSum': salesSum,
                   'topUser': topUser})

