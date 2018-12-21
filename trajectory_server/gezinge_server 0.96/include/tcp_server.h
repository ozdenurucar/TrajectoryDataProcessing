#ifndef TCP_SERVER_H
#define TCP_SERVER_H

#include <string>
#include <QObject>
#include <QTcpServer>
#include <QTcpSocket>
#include <QDebug>
#include "json.hpp"

class tcp_server : public QObject
{
    Q_OBJECT
public:
    explicit tcp_server(QObject *parent = nullptr);

public slots:
    void newConncetion();
    void service_call();
private:
    QTcpServer *server{};
    QTcpSocket *socket{};

	std::string call_reduction(nlohmann::json j);
    std::string call_query(nlohmann::json j);


};

#endif // TCP_SERVER_H
