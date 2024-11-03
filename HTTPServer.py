from http.server import BaseHTTPRequestHandler, HTTPServer
import urllib.parse
import csv
from datetime import datetime
import os

filename = ""

class MyRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        print("Received")
        parsed_path = urllib.parse.urlparse(self.path)
        query_params = urllib.parse.parse_qs(parsed_path.query)

        if parsed_path.path == '/send' and 'event_type' in query_params:
            event_type_value = query_params['event_type'][0]
            timestamp = int(datetime.now().timestamp() * 1000)
            global filename
            if not os.path.exists(filename):
                with open(filename, 'w', newline='') as csvfile:
                    csv_writer = csv.writer(csvfile)
                    csv_writer.writerow(['event_type', 'timestamp'])

            with open(filename, 'a', newline='') as csvfile:
                csv_writer = csv.writer(csvfile)
                csv_writer.writerow([event_type_value, timestamp])

            self.send_response(200)
            self.send_header('Content-type', 'text/html')
            self.end_headers()
            self.wfile.write(b'Successfully wrote to CSV file.')

        else:
            self.send_response(400)
            self.send_header('Content-type', 'text/html')
            self.end_headers()
            self.wfile.write(b'Invalid request.')

def run():
    global filename
    participant_id = input("Student ID:")
    session_id = input("Session ID:")
    scene_id = input("Scene ID:")
    filename = f'{participant_id}_session{session_id}_scene{scene_id}.csv'

    server_address = ('', 8000)
    httpd = HTTPServer(server_address, MyRequestHandler)
    print('Starting server on port 8000...')
    print(f'Saving data to file: {filename}')
    httpd.serve_forever()

if __name__ == '__main__':
    run()
