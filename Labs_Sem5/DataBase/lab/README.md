# Lab2Mongo
Lysogor Dmytro, KP-42
###Завдання:

1. Розробити схему бази даних на основі предметної галузі з ЛР№2-Ч1 у
спосіб, що застосовується в СУБД MongoDB.
2. Розробити модуль роботи з базою даних на основі пакету PyMongo.
3. Реалізувати дві операції на вибір із використанням паралельної обробки
даних Map/Reduce.
4. Реалізувати обчислення та виведення результату складного агрегативного
запиту до бази даних з використанням функції aggregate() сервера
MongoDB.

### Приклади коду
* Агрегація

```Python
        pipeline = [
            {"$group": {"_id": "$user.name", "count": {"$sum": 1}}},
            {"$sort": SON([("count", -1)])}
        ]
```

* MapReduce

```Python
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
```