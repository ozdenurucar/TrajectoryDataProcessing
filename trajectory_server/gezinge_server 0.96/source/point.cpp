#include "include/point.h"

point::point(const double x = 0.0, const double y = 0.0) : x{ x }, y{ y }
{

}

point::point(const std::pair<double, double> xy) : x{ xy.first }, y{ xy.second }
{

}

bool point::operator<(point _sec_point) const
{
	return (x < _sec_point.x && y < _sec_point.y);
}

bool point::operator<=(point _sec_point) const
{
	return (x <= _sec_point.x && y <= _sec_point.y);
}

std::pair<double, double> point::get_point() const
{
	return std::pair<double, double>(x, y);
}

double point::perpendicular_distance(point & p1, point & p2)
{
	return std::fabs(p1.x * p2.y - p1.y*p2.x) / std::sqrt(std::pow(p2.x, 2) + std::pow(p2.y, 2));
}

void to_json(nlohmann::json & j, const point & p)
{
	j = nlohmann::json{ { "X", p.x },{ "Y", p.y } };
}

void from_json(const nlohmann::json & j, point & p)
{
	p.x = j["X"];
	p.y = j["Y"];
}
