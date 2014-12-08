Now we'll talk about Networking.

Diapo How will it work:
What we want is to send the model's data to a server running Unity.

And in the server, we also have to create a little simple plugin with a few lines. It will be very light.

Diapo External application:
to send data, we first thought of Internet Protocols. We tried the most used protocols, which are http and ftp but there was some problem.

Http wasn't made for sending this kind of data to a server.

Ftp was too complicated to use for the user (using a login, a password and an IP adress)

We also didn't want to use another software than Unity because it will use more resources.

Diapo Classic Networking:
So this is a quick draw on sending data using the protocols. Not optimized. (with login, password, IP adress)

Diapo Assets:
In Unity there are assets which are like Java Class and there is some documentation in the internet.
To simplify, it works like this, like a highway between 2 devices running unity.
