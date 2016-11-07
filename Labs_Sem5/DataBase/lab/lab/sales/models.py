# Create your models here.

class User:
    def __init__(self, name, surname, age):
        self.name = name
        self.surname = surname
        self.age = age

    def mongify(self):
        return {"name": self.name, "surname": self.surname, "age": self.age}


def userFromDict(dict):
    customer = User(dict['name'], dict['surname'], dict['age'])
    return customer


class Department:
    def __init__(self, name, address):
        self._id = id
        self.name = name
        self.address = address

    def mongify(self):
        return {"name": self.name, "address": self.address}


def departmentFromDict(dict):
    department = Department(dict['name'], dict['address'])
    return department


class Product:
    def __init__(self, name, price):
        self._id = id
        self.name = name
        self.price = price

    def mongify(self):
        return {"name": self.name, "price": self.price}


def productFromDict(dict):
    product = Product(dict['name'], dict['price'])
    return product


class Sale:
    def __init__(self, user, department, product, saletype, description):
        self.user = user
        self.department = department
        self.product = product
        self.saletype = saletype
        self.description = description

    def mongify(self):
        return {"user": self.user.mongify(), "department": self.department.mongify(),
                "product": self.product.mongify(), "saletype": self.saletype, "description": self.description}

