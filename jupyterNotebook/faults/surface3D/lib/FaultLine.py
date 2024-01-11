import numpy as np

class FaultLine:
    def __init__(self, origin, dip_angle, strike):
        self.origin = np.array(origin)  # Точка разлома (North, East, TVD)
        self.dip_angle = np.radians(dip_angle)  # Угол падения в радианах
        self.strike = np.radians(strike)        # Направление в радианах

    def get_direction_vector(self):
        # Вычисление вектора направления линии разлома
        # Учитывая, что strike - это угол относительно Севера, и dip - угол падения
        dx = np.sin(self.strike) * np.cos(self.dip_angle)
        dy = np.cos(self.strike) * np.cos(self.dip_angle)
        dz = np.sin(self.dip_angle)
        return np.array([dx, dy, dz])

    def plot_on(self, plotter, length=1000, color='red'):
        # Визуализация линии разлома
        direction = self.get_direction_vector()
        end_point = self.origin + direction * length
        plotter.ax.plot([self.origin[0], end_point[0]], 
                        [self.origin[1], end_point[1]], 
                        [self.origin[2], end_point[2]], 
                        color=color)
