from django.conf.urls import url

from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^list/$', views.listView),
    url(r'^remove/([0-9a-f]{24})$', views.removeSale),
    url(r'^([0-9a-f]{24})$', views.editSale),
    url(r'^add/$', views.addSale),
]