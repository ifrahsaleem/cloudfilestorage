# cloudfilestorage

I have implemented a client-server application, which will operate as a cloud file
storage and publishing system. In the application, there will be a Server module which stores
and manages files uploaded by Client modules. Each file on the server belongs to the client
who uploaded it and only that client can delete, copy or choose to publish the file so that other
clients in the system can download.
The server listens on a predefined port and accepts incoming client connections. There may
be one or more clients connected to the server at the same time. Each client knows the IP
address and the listening TCP port of the server (to be entered through the Graphical User
Interface (GUI)). Clients connect to server on corresponding port and identify themselves
with their names. Server needs to keep the names of currently connected clients to avoid the
same name to be connected more than once at a given time.
