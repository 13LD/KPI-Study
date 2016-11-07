from django import template
from django.core.urlresolvers import reverse
from django.http import HttpResponse
from bson.objectid import ObjectId
from django.shortcuts import render, redirect
from Database import DB
from models import User, Product, Department, Sale, userFromDict, productFromDict, departmentFromDict

# Create your views here.

database = DB()


def index(request):
    avgUsers = database.avgAgeOfUsers()
    salesSum = database.countSalesSum()
    topUser = database.analyzeOrders()
    return render(request, 'adminpage.html',
                  {'message': request.GET.get('message', None), 'avgAge': avgUsers, 'salesSum': salesSum,
                   'topUser': topUser})


def listView(request):
    salesList = [sale for sale in database.sales.find()]
    return render(request, 'listpage.html', {'list': salesList})


def removeSale(request, id):
    database.deleteSaleById(id)
    return redirect(reverse('index') + '?message=Removed record')


def editSale(request, id):
    if request.method == 'GET':
        customers = database.users.find()
        departments = database.departments.find()
        products = database.products.find()
        sale = database.sales.find_one({"_id": ObjectId(id)})
        return render(request, 'editSale.html',
                      {'customers': customers, 'departments': departments, 'products': products, 'sale': sale})
    else:
        customer = database.getUserById(request.POST['userId'])
        department = database.getDepartmentById(request.POST['departmentId'])
        product = database.getProductById(request.POST['productId'])
        sale = Sale(customer, department, product, request.POST['saleType'], request.POST['saleDescription'])
        database.sales.update_one({"_id": ObjectId(id)}, {'$set': sale.mongify()})

        return redirect(reverse('index') + '?message=Changed Sale')


def addSale(request):
    if request.method == 'GET':
        customers = database.users.find()
        departments = database.departments.find()
        products = database.products.find()
        return render(request, 'addSale.html',
                      {'customers': customers, 'departments': departments, 'products': products})
    elif request.method == 'POST':
        customer = database.getUserById(request.POST['userId'])
        department = database.getDepartmentById(request.POST['departmentId'])
        product = database.getProductById(request.POST['productId'])
        sale = Sale(customer, department, product, request.POST['saleType'], request.POST['saleDescription'])
        database.sales.insert(sale.mongify())
        return redirect(reverse('index') + '?message=Added Sale')
