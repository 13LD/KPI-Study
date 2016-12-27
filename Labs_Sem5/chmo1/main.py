import thread

import part1
import math
import plotIters as plt




def newtons_method(x0, e):
    xk = x0
    x1 = 0
    iterlist = list()

    while True:
        x1 = xk - (part1.equation(xk) / part1.equation_dx(x0))
        if abs(x1 - xk) < e:
            return [iterlist, iterlist]
        xk = x1
        iterlist.append(xk)
    print "Newton : " + str(x1)

#Root1
a1 = -9.0
b1 = -7.5

#Root2
a2 = -5.0
b2 = -4.5

#Root3
a3 = 4.5
b3 = 5

#Root
a4 = 1.4
b4 = 1.7

#Root5
a5 = -1.7
b5 = -1.4



e = 0.0000001
lists = []

lists.append(newtons_method(a1, e))
lists.append(newtons_method(a2, e))
lists.append(newtons_method(a3, e))
lists.append(newtons_method(a4, e))
lists.append(newtons_method(a5, e))


f = open("part1.txt", "w")
for item in lists:
    f.write(str(item) + "\n")
f.close()

if (part1.equation(a1) * part1.equation(b1)) < 0:
    print "OK"
    lists = newtons_method(a3, e)
    plt.build_iter_graphics(lists)
else:
    print "Wrong bounds"
