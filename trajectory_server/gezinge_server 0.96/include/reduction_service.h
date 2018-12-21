#ifndef reduction_service_h
#define reduction_service_h

#include <vector>
#include <utility>
#include <cmath>
#include <chrono>
#include <json.hpp>
#include "include/point.h"

class reduction_service
{
public:
    std::vector<point> reduction(std::vector<point>& data_to_reduce); // indirgeme sonucu
    double elapsed_time() const; // gecen zaman donusu
    double ratio() const; //oran donusu

private:
	double _ratio; //oran
	double _elapsed_time; //gecen zaman
	
	const std::pair<int, double> max_distance(const std::vector<point>& points) const;
	std::vector<point> douglas_peucker(std::vector<point>& points, double epsilon) const; //indirgeme algoritmasi
};
#endif
