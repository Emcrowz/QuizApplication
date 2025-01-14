import { useEffect, useState } from "react";
import { Participant } from "../Models/Participant";
import { useNavigate } from "react-router-dom";
import { API_ROUTE } from "../Constants/RoutesAndPaths";

export const Leaderboard: React.FC = () => {
  const navigate = useNavigate();
  let index = 1;

  const [participants, setParticipants] = useState<Participant[]>([]);

  useEffect(function () {
    fetch(API_ROUTE.PARTICIPANTS)
      .then((res) => res.json())
      .then((data) => setParticipants(data))
      .catch((error) => console.log(error));
  }, []);

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div>
      <h1>Hello world! I am Leaderboard page!</h1>

      <ul>
        {participants.map((participant) => (
          <li
            className={
              index === 1
                ? "bg-amber-400"
                : index === 2
                ? "bg-zinc-400"
                : index === 3
                ? "bg-amber-800"
                : "bg-blue-200"
            }
            key={index}
          >
            {index++} : {participant.email} | Score: {participant.score} |
            Participated: {participant.participationDate.toString()}
          </li>
        ))}
      </ul>

      <button type="button" onClick={handleNavigateToStart}>
        Back to start
      </button>
    </div>
  );
};
