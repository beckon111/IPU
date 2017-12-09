#!/usr/bin/env python3
import os
from http.server import HTTPServer, CGIHTTPRequestHandler
server_address = ("", 8000)
httpd = HTTPServer(server_address, CGIHTTPRequestHandler)
httpd.serve_forever()
os.popen("""/usr/bin/open -a Safari http://127.0.0.1:8000""")