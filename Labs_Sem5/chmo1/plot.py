from matplotlib import pyplot as plt


def build_sub_graphic(function, a, b, color='red'):
    x_list = []
    y_list = []
    i = a
    step = 0.01
    while i <= b:
        x_list.append(i)
        y_list.append(function(i))
        i += step

    plt.plot(x_list, y_list, color=color)


def build_coordinate_system():
    plt.plot([-100, 100], [0, 0], color='black')
    plt.plot([0, 0], [-100, 100], color='black')


def build_graphics(*args):
    build_coordinate_system()
    for arg in args:
        build_sub_graphic(arg[0], arg[1], arg[2], arg[3])
    plt.xlim(-100, 100)
    plt.ylim(-100, 100)
    plt.show()



