#include "include/query_service.h"
#include <random>

query_service::qt_node::qt_node(qt_node * parent = nullptr) 
	: parent{ parent } 
{ 

}
query_service::qt_node::qt_node(std::nullptr_t, qt_node * parent = nullptr) 
	: child{ nullptr,nullptr,nullptr,nullptr }, parent{ parent } 
{ 

}
point& query_service::qt_node::data()
{ 
	return _data; 
}
point& query_service::qt_node::bottom_left()
{ 
	return _bottom_left; 
};
point& query_service::qt_node::top_right()
{ 
	return _top_right; 
};

bool query_service::qt_node::insert(point& p, int index)
{
	int sect = get_section(p);
	if (child[sect] == nullptr)
	{
		child[sect] = new qt_node(nullptr,this);
		child[sect]->data() = p;
		child[sect]->index = index;
		child[sect]->set_boundries(sect);
		return true;
	}
	return child[sect]->insert(p,index);
}

int query_service::qt_node::get_section(point &p)
{
	if (p.x >= _data.x && p.y > _data.y) return 0;
	else if (p.x < _data.x && p.y >= _data.y) return 1;
	else if (p.x <= _data.x && p.y < _data.y) return 2;
	else return 3;
}

void query_service::qt_node::set_boundries(int sect)
{
	switch (sect)
	{
	case 0:
		_top_right = parent->_top_right;
		_bottom_left = parent->_data;
		break;
	case 1:
		_top_right = { parent->_data.x,parent->_top_right.y };
		_bottom_left = { parent->_bottom_left.x, parent->_data.y };
		break;
	case 2:
		_top_right = parent->_data;
		_bottom_left = parent->_bottom_left;
		break;
	case 3:
		_top_right = { parent->_top_right.x,parent->_data.y };
		_bottom_left = { parent->_data.x,parent->_bottom_left.y };
		break;
	}
}

query_service::qt_node::~qt_node()
{
	for (int i = 0; i < 4; i++)
	{
		if (child[i] != nullptr)
		{
			delete child[i];
			child[i] = nullptr;
		}
	}
}

query_service::quad_tree::quad_tree(std::vector<point>& list)
	: root(nullptr)
{
	for (int i = 0; i < list.size(); i++)
	{
		insert(list[i], i);
	}
}
bool query_service::quad_tree::insert(point& p,int index)
{
	if (root == nullptr)
	{
		root = new qt_node(nullptr);
		root->data() = p;
		root->bottom_left() = { -180,-90 };
		root->top_right() = { 180,90 };
		return true;
	}
	return root->insert(p,index);

}

query_service::quad_tree::~quad_tree()
{
	if (root != nullptr)
	{
		delete root;
		root = nullptr;
	}
}

query_service::query_service(std::vector<point> points, point bottom_left, point top_right) 
	: tree(points)
{
	query(tree.root, bottom_left, top_right);
}

query_service::~query_service()
{

}

std::vector<point> query_service::query_result()
{
	return results;
}

std::vector<int> query_service::index_result()
{
	return index;
}

query_service::intersection_state query_service::boundry_intersection(qt_node * data, point& bottom_left, point& top_right)
{
	if (data == nullptr)
		return NONE;

	if (data->top_right().x < bottom_left.x ||
		data->bottom_left().x > top_right.x ||
		data->top_right().y < bottom_left.y ||
		data->bottom_left().y > top_right.y) 
	{
		return NONE;
	}
	return INSIDE;
}

void query_service::query(qt_node * data, point& bottom_left, point& top_right)
{
	if (data == nullptr)
		return;

		if (data->data().x < top_right.x
			&& data->data().x > bottom_left.x
			&& data->data().y > bottom_left.y
			&& data->data().y < top_right.y)
		{
			results.push_back(data->data());
			index.push_back(data->index);
		}
		for (int i = 0; i < 4; i++)
			query(data->child[i], bottom_left, top_right);



}





