#pragma once
#include <utility>
#include "json.hpp"
struct point // nokta sinifi
{
	point() {}
	point(double x, double y);
	point(std::pair<double, double> xy);
	bool operator<(point _sec_point) const;  //kucuktur operator
	bool operator<=(point _sec_point) const; //kucuk esittir operator
	std::pair<double, double> get_point() const;
	static double perpendicular_distance(point& p1, point& p2); //dikey uzaklik
	double x, y;
};

void to_json(nlohmann::json& j, const point& p);
void from_json(const nlohmann::json& j, point& p);
