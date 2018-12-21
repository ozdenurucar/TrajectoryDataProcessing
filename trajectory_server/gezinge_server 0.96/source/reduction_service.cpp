#include "include/reduction_service.h"
#include <iostream>

const std::pair<int, double> reduction_service::max_distance(const std::vector<point>& points) const
{
	point first = points[0];
	point last = points[points.size() - 1];
	int index{ 0 };
	double max_dist = -1;
	point p = { last.x - first.x,last.y - first.y };
	for (int i = 1; i < points.size() - 1; i++)
	{
		point pp = { points[i].x - first.x, points[i].y - first.y };
		double d = point::perpendicular_distance(pp,p);
		if (d > max_dist)
		{
			max_dist = d;
			index = i;
		}
	}
	return std::make_pair(index, max_dist);
}

std::vector<point> reduction_service::douglas_peucker(std::vector<point>& points, double epsilon = 0.000001) const
{
	if (points.size() < 3)
		return points;
	std::pair<int,double> m_dist = max_distance(points);
	if (m_dist.second >= epsilon)
	{
		int index = m_dist.first;		
		std::vector<point> vec1(points.begin(), points.begin() + index + 1);
		std::vector<point> vec2(points.begin() + index + 1, points.end());
		auto res_1 = douglas_peucker(vec1, epsilon);
		auto res_2 = douglas_peucker(vec2, epsilon);
		std::vector<point> result(res_1);
		result.pop_back();
		result.insert(result.end(), res_2.begin(), res_2.end());
		return result;
	}
	else		
	{
		std::vector<point> result;
		result.push_back(points[0]);
		result.push_back(points[points.size()-1]);
		return result;
	}
}

std::vector<point> reduction_service::reduction(std::vector<point>& data_to_reduce)
{
    using namespace std::chrono;
	std::cout << "before: " << data_to_reduce.size() << "\n\n";
	const auto begin = high_resolution_clock::now();
    auto result = douglas_peucker(data_to_reduce,0.000005);
	const auto end = high_resolution_clock::now();
	std::cout << "after: " << result.size() << "\n\n";
	_elapsed_time = duration<double>((end - begin)).count();	
    _ratio = (1 - (double(result.size()))/data_to_reduce.size()) * 100;
    return result;
}

double reduction_service::elapsed_time() const
{
	return _elapsed_time;
}
double reduction_service::ratio() const
{
	return _ratio;
}
