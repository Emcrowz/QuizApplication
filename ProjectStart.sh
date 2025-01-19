echo "QuizApplication project is launching"
echo ""

echo "Web API booting..."
(cd ./QuizApplication.Server && dotnet build && dotnet run) &
API_PID=$!

echo "Web client (React/TS) booting..."
(cd ./quizapplication.client && npm install && npm run dev) &
CLIENT_PID=$!

# Function to terminate both processes
terminate_processes() {
    echo "== NodeJS and Dotnet background process cleanup =="
    echo "=Starting background nodejs cleanup.="
    pkill -fe 'node'
    echo "=All node processes terminated.="

    echo "=Starting background dotnet cleanup.="
    pkill -fe 'dotnet'
    echo "=All dotnet processes terminated.="
}

echo "[Web API]: http://localhost:5170 (HTTP) | https://localhost:7219 (HTTPS)"
echo "[Web Client]: https://localhost:64905" 
echo "[Web API] PID: $API_PID"
echo "[Web client] PID: $CLIENT_PID"

# Wait for user input to terminate processes
echo "Press [X] to terminate both running processes."
while : ; do
    read -n 1 key
    if [[ $key = X ]]; then
        terminate_processes
        break
    fi
done