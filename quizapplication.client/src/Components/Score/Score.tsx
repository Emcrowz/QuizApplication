import { useNavigate } from "react-router-dom";
import { Participant } from "../../Models/Participant";
import React, { useState, useEffect } from "react";
import { useDebounce } from "../../Hooks/useDebounce";
import { SubmitParticipantData } from "../Utils/Participants/SubmitParticipantData";

export const Score: React.FC<Participant> = ({
  email,
  name,
  participationDate,
  finalAnswers,
  score,
}) => {
  const navigate = useNavigate();
  const [finalScore, setfinalScore] = useState(0);

  const debouncedSubmitParticipantData = useDebounce(async () => {
    const result = await SubmitParticipantData(
      email,
      name,
      participationDate,
      finalAnswers,
      score
    );
    setfinalScore(result!.finalScore);
  });

  useEffect(() => {
    debouncedSubmitParticipantData();
  }, []);

  const handleNavigateToLeaderboard = () => {
    navigate("/leaderboard");
  };

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="my-6 flex h-screen justify-center">
      <div className="content-center">
        <div className="border-2 border-blue-300/50 p-12 rounded-xl bg-blue-300/75">
          <h1 className="text-6xl text-center select-none">
            Your final score:{" "}
          </h1>
          <p className="text-4xl text-center font-bold my-6 select-none">
            {finalScore}
          </p>
          <div className="flex justify-between">
            <button
              type="button"
              className="bg-amber-500/65 rounded-xl p-4 hover:bg-amber-400/85"
              onClick={handleNavigateToLeaderboard}
            >
              Check the Leaderboard
            </button>
            <button
              type="button"
              className="bg-green-500/65 rounded-xl p-4 hover:bg-green-400/85"
              onClick={() => {
                window.location.reload();
                handleNavigateToStart();
              }}
            >
              Start again
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
