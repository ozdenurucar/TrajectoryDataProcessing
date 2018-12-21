#pragma once
#include <vector>
#include "include/point.h"

class query_service
{
public:

	class qt_node
	{
		point _data;
		point _bottom_left;
		point _top_right;
		qt_node* parent;
	public:
		qt_node * child[4];
		int index;
		qt_node(qt_node * parent);
		qt_node(std::nullptr_t, qt_node * parent);
		point& data();
		point& bottom_left();
		point& top_right();
		bool insert(point& p, int index);
		int get_section(point &p);
		void set_boundries(int sect);
		~qt_node();
	};
	class quad_tree
	{
		
	public:
		qt_node * root;
		quad_tree(std::vector<point>& list);
		bool insert(point& p,int index);
		~quad_tree();
	};
	

	enum intersection_state
	{
		INSIDE,
		NONE
	};


	query_service(std::vector<point> points, point bottom_left, point top_right);
	~query_service();

	std::vector<point> query_result();
	std::vector<int> index_result();
private:
	void query(qt_node* node, point& bottom_left, point& top_right);
	intersection_state boundry_intersection(qt_node * node, point& bottom_left, point& top_right);
	quad_tree tree;
	std::vector<point> results;
	std::vector<int> index;


};

