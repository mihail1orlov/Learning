from .Point import Point
from .Point3d import Point3d

class PointHelper:
    @staticmethod
    def find_min_max_points(points):
        if not points:
            return None, None

        # Устанавливаем начальные границы на основе первой точки
        min_point = Point(points[0].x, points[0].y, points[0].z)
        max_point = Point(points[0].x, points[0].y, points[0].z)

        # Проходимся по каждой точке и обновляем границы при необходимости
        for point in points:
            if point.x < min_point.x:
                min_point.x = point.x
            if point.y < min_point.y:
                min_point.y = point.y
            if point.z < min_point.z:
                min_point.z = point.z

            if point.x > max_point.x:
                max_point.x = point.x
            if point.y > max_point.y:
                max_point.y = point.y
            if point.z > max_point.z:
                max_point.z = point.z

        return min_point, max_point
    
    @staticmethod
    def get_intersection_point(plane, x=None, y=None, z=None, min_point=None, max_point=None):
        if x is not None:
            if plane.B == 0:  # Plane is parallel to the y-axis
                if min_point is not None and max_point is not None:
                    y = (min_point.y + max_point.y) / 2  # Use midpoint y-coordinate of the bounding box
                else:
                    raise ValueError("min_point and max_point should be provided when plane is parallel to y-axis.")
            else:
                z = 0 if z is None else z
                y = -(plane.A * x + plane.C * z + plane.D) / plane.B
            return Point(x, y, z)

        if y is not None:
            if plane.A == 0:  # Plane is parallel to the x-axis
                x = (min_point.x + max_point.x) / 2  # Use midpoint x-coordinate of the bounding box
            else:
                z = 0 if z is None else z
                x = -(plane.B * y + plane.C * z + plane.D) / plane.A
            return Point(x, y, z)

        if z is not None:
            if plane.C == 0:  # Plane is parallel to the z-axis
                z = (min_point.z + max_point.z) / 2  # Use midpoint z-coordinate of the bounding box
            else:
                x = 0 if x is None else x
                z = -(plane.A * x + plane.B * y + plane.D) / plane.C
            return Point(x, y, z)

    @staticmethod
    def get_three_points_on_plane(plane, min_point, max_point):
        intersections = []

        # Проверка каждого ребра
        for z in [min_point.z, max_point.z]:
            point = PointHelper.get_intersection_point(plane, x=min_point.x, z=z)
            if min_point.y <= point.y <= max_point.y:
                intersections.append(point)

            point = PointHelper.get_intersection_point(plane, x=max_point.x, z=z)
            if min_point.y <= point.y <= max_point.y:
                intersections.append(point)

        for x in [min_point.x, max_point.x]:
            point = PointHelper.get_intersection_point(plane, y=min_point.y, x=x)
            if min_point.z <= point.z <= max_point.z:
                intersections.append(point)

            point = PointHelper.get_intersection_point(plane, y=max_point.y, x=x)
            if min_point.z <= point.z <= max_point.z:
                intersections.append(point)

        for y in [min_point.y, max_point.y]:
            point = PointHelper.get_intersection_point(plane, z=min_point.z, y=y)
            if min_point.x <= point.x <= max_point.x:
                intersections.append(point)

            point = PointHelper.get_intersection_point(plane, z=max_point.z, y=y)
            if min_point.x <= point.x <= max_point.x:
                intersections.append(point)

        # Сортируем точки по убыванию суммы их координат
        sorted_points = sorted(intersections, key=lambda p: p.x + p.y + p.z, reverse=True)

        # Возвращаем первые три точки из отсортированного списка
        return sorted_points[0], sorted_points[1], sorted_points[2]
    
    @staticmethod
    def convert_to_point3d(points_array, default_color='r', default_name=''):
        """
        Convert a list of Point objects to Point3d objects.

        Args:
        - points_array (list of Point): List of Point objects.
        - default_color (str): Default color for Point3d objects.
        - default_name (str): Default name for Point3d objects.

        Returns:
        - List of Point3d objects.
        """
        return [Point3d(point.x, point.y, point.z, default_color, default_name) for point in points_array]