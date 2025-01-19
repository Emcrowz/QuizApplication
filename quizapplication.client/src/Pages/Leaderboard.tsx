import { useEffect, useState } from "react";
import { Participant } from "../Models/Participant";
import { useNavigate } from "react-router-dom";
import { useDebounce } from "../Hooks/useDebounce";
import { FetchTopTenParticipants } from "../Components/Utils/Participants/FetchTopTenParticipants";

export const Leaderboard: React.FC = () => {
  const navigate = useNavigate();
  let index = 1;

  const [participants, setParticipants] = useState<Participant[]>([]);

  const debouncedFetchTopTenParticipants = useDebounce(async () => {
    const result = await FetchTopTenParticipants();
    setParticipants(result!.participants);
  });

  useEffect(() => {
    debouncedFetchTopTenParticipants();
  }, []);

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="flex justify-center h-screen mx-auto my-6">
      <div className="content-center">
        <div className="border-2 border-blue-300/50 p-12 rounded-xl bg-blue-300/75">
          <h1 className="text-center text-8xl my-4 select-none">Leaderboard</h1>

          <ul>
            {participants.map((participant) => (
              <li
                className={
                  index === 1
                    ? "bg-amber-400 p-2 my-4 rounded-xl text-2xl text-center select-none"
                    : index === 2
                    ? "bg-zinc-400 p-2 my-3 rounded-xl text-xl text-center select-none"
                    : index === 3
                    ? "bg-amber-800 p-2 my-2 rounded-xl text-lg text-center select-none"
                    : "bg-slate-400/25 p-2 my-2 rounded-xl text-center select-none"
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
    </div>
  );
};
