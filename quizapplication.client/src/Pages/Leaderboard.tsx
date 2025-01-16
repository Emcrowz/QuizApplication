import { useEffect, useState } from "react";
import { Participant } from "../Models/Participant";
import { useNavigate } from "react-router-dom";
import { getTopTenParticipants } from "../Components/Utils/ParticipantsApi";

export const Leaderboard: React.FC = () => {
  const navigate = useNavigate();
  let index = 1;

  const [participants, setParticipants] = useState<Participant[]>([]);

  useEffect(() => {
    const fetchTopTenParticipants = async () => {
      try {
        const data = await getTopTenParticipants();
        setParticipants(data);
      } catch (error) {
        console.log(error);
      }
    };

    fetchTopTenParticipants();
  }, []);

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="flex justify-center h-screen mx-auto my-6">
      <div>
        <h1 className="text-center text-8xl my-4">Leaderboard</h1>

        <ul>
          {participants.map((participant) => (
            <li
              className={
                index === 1
                  ? "bg-amber-400 my-4 rounded-xl text-2xl"
                  : index === 2
                  ? "bg-zinc-400 my-3 rounded-xl text-xl"
                  : index === 3
                  ? "bg-amber-800 my-2 rounded-xl text-lg"
                  : "bg-blue-200 my-2 rounded-xl"
              }
              key={index}
            >
              {index++} : {participant.email} | Score: {participant.score} |
              Participated: {participant.participationDate.toLocaleString()}
            </li>
          ))}
        </ul>

        <div className="flex justify-center mt-6">
          <button
            className="bg-green-500/65 rounded-xl p-4 hover:bg-green-400/85"
            type="button"
            onClick={handleNavigateToStart}
          >
            Back to start
          </button>
        </div>
      </div>
    </div>
  );
};
