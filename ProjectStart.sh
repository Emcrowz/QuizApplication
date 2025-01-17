echo "QuizApplication project is launching"
echo "Web API booting..."
(cd ./QuizApplication.Server && dotnet build && dotnet run) &
echo "Web client (React/TS) booting..."
(cd ./quizapplication.client && npm install && npm run dev) &

# gnome-terminal -- bash -c "cd ./QuizApplication.Server && dotnet build && dotnet run"
# gnome-terminal -- bash -c "cd ./quizapplication.client && npm install && npm run dev"