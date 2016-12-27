from matplotlib import pyplot as plt

def build_coordinate_system():
    plt.plot([-100, 100], [0, 0], color='black')
    plt.plot([0, 0], [-100, 100], color='black')


def build_iter_graphics(x_list):
    build_coordinate_system()
    for list in x_list:
        plt.plot(range(0,len(list)),list)
    plt.xlim(-50, 50)
    plt.ylim(-50, 50)
    plt.show()