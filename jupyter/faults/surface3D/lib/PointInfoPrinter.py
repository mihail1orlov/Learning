class PointInfoPrinter:

    @staticmethod
    def print_point(point, index=None):
        """
        Print the details of a Point3d object.

        Args:
        - point (Point3d): The Point3d object to print.
        - index (int): Optional index of the point in a list.
        """
        index_str = f"index={index} " if index is not None else ""
        print(f"{index_str}(x={point.x}, y={point.y}, z={point.z}, color={point.color})")

    @staticmethod
    def print_points(points):
        """
        Print the details of a list of Point3d objects.

        Args:
        - points (list of Point3d): The list of Point3d objects to print.
        """
        for idx, point in enumerate(points, 1):  # Start indexing from 1
            PointInfoPrinter.print_point(point, index=idx)

    @staticmethod
    def print_summary(points):
        """
        Print a summary of a list of Point3d objects.

        Args:
        - points (list of Point3d): The list of Point3d objects to summarize.
        """
        num_points = len(points)
        average_x = sum(point.x for point in points) / num_points
        average_y = sum(point.y for point in points) / num_points
        average_z = sum(point.z for point in points) / num_points

        print(f"Summary:")
        print(f"Total Points: {num_points}")
        print(f"Average x-coordinate: {average_x:.2f}")
        print(f"Average y-coordinate: {average_y:.2f}")
        print(f"Average z-coordinate: {average_z:.2f}")
