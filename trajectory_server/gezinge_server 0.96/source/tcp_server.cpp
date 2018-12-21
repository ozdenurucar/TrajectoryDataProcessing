#include "include/tcp_server.h"
#include "include/reduction_service.h"
#include "include/query_service.h"
#include <Qstring>
#include <iostream>
#include <vector>
#include <string>

tcp_server::tcp_server(QObject *parent) : QObject(parent)
{
    server = new QTcpServer(this);
    connect(server, SIGNAL(newConnection()),
               this, SLOT(newConncetion()));

    if(!server->listen(QHostAddress::AnyIPv4, 9999))
    {
		std::cout << "Server could not start";
    }
    else
    {
		std::cout << "Server started!\n";
    }
}

void tcp_server::newConncetion()
{
	std::cout << "SOCKET IS OPENED\n";
    socket = server->nextPendingConnection();
    connect(socket, SIGNAL(readyRead()), this, SLOT(service_call()));
	std::cout  << "CONNECTED\n";
}
void tcp_server::service_call()
{   
	using namespace nlohmann;
	try
	{
		socket->waitForReadyRead(300);
		std::cout << "Data is receiving... \n";
		QByteArray bytesReceived;
		bytesReceived += char(socket->bytesAvailable());
		json data;
		data = json::parse(socket->readAll());
		if (data["service_ID"] == 0)
		{
			socket->write(call_reduction(data).c_str());
			socket->waitForBytesWritten(3000);
		}
		else
		{
			std::string xx = call_query(data);
			socket->write(xx.c_str());
			socket->waitForBytesWritten(3000);
		}
		std::cout << "data sent succesfully\nSOCKET IS CLOSED\n.\n.\n.\n.\n";
		socket->close();
	}
	catch(json::exception & e)
	{
		std::cout << e.what() << std::endl;
		std::cout << "FATAL ERROR! \nMaybe because of data loss or bad connection???\nSOCKET IS CLOSING!!\n.\n.\n.\n.\n";
		socket->close();
	}	
}

std::string tcp_server::call_reduction(nlohmann::json j)
{
	using namespace nlohmann;
	std::vector<point> data_to_reduct;
	std::cout << "REDUCTION SERVICE.\nconfiguring data...\n";
	try
	{
		for (auto& it : j["data"])
		{
			data_to_reduct.push_back(point(it["X"], it["Y"]));
		}
	}
	catch (json::exception & e)
	{
		std::cout << e.what();
	}
	reduction_service r{};
	json result;
	json json_array;
	std::cout << "data configured successfully\nREDUCING!!!\n";
	auto res = r.reduction(data_to_reduct);
	std::cout << "data reduced succesfully\n Sending\n";
	for (auto it : res)
	{
		json_array.push_back(point{ it.x,it.y });
	}
	result["data"] = json_array;
	result["ratio"] = r.ratio();
	result["elapsed_time"] = r.elapsed_time();
	return result.dump();
}

std::string tcp_server::call_query(nlohmann::json j)
{
	using namespace nlohmann;
	std::vector<point> vec;
    std::cout << "QUERY SERVICE!\nconfiguring data...\n";
	for (auto it : j["Data"])
		vec.push_back({ it["X"], it["Y"] });
	query_service query(vec,point(j["min_point"]["X"], j["min_point"]["Y"]),
							point(j["max_point"]["X"], j["max_point"]["Y"]));
	std::vector<point> rest = query.query_result();
	
	json res;
	res["data"] = rest;
	res["index"] = query.index_result();


    return res.dump();
}
