echo "QuizApplication project is launching"
echo "Client: https://localhost:64905 | API: http://localhost:5170 (HTTP) | https://localhost:7219 (HTTPS)"
echo "Web API booting..."
(cd ./QuizApplication.Server && dotnet build && dotnet run) &
API_PID=$!
echo "Web client (React/TS) booting..."
(cd ./quizapplication.client && npm install && npm run dev) &
CLIENT_PID=$!

echo "Web API PID: $API_PID"
echo "Web client PID: $CLIENT_PID"

# Check if the API process is running
if ps -p $API_PID > /dev/null; then
    # Terminate the API process
    kill $API_PID
    echo "API process $API_PID has been terminated."
else
    echo "API process $API_PID is not running."
fi

# Check if the client process is running
if ps -p $CLIENT_PID > /dev/null; then
    # Terminate the client process
    kill $CLIENT_PID
    echo "Client process $CLIENT_PID has been terminated."
else
    echo "Client process $CLIENT_PID is not running."
fi

# gnome-terminal -- bash -c "cd ./QuizApplication.Server && dotnet build && dotnet run"
# gnome-terminal -- bash -c "cd ./quizapplication.client && npm install && npm run dev"