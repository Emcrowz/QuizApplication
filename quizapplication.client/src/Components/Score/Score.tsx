import { useNavigate } from "react-router-dom";
import { Participant } from "../../Models/Participant";
import React, { useState, useEffect } from "react";
import { postParticipant } from "../Utils/ParticipantsApi";

export const Score: React.FC<Participant> = ({
  email,
  name,
  participationDate,
  finalAnswers,
  score,
}) => {
  const navigate = useNavigate();
  const [finalScore, setfinalScore] = useState<number>(0);

  useEffect(() => {
    const submitParticipant = async () => {
      try {
        const data = await postParticipant({
          email,
          name,
          participationDate,
          finalAnswers,
          score,
        });
        setfinalScore(data.score);
      } catch (error) {
        console.error("Error submitting participant:", error);
      }
    };

    submitParticipant();
  }, [email, name, participationDate, finalAnswers, score]);

  const handleNavigateToLeaderboard = () => {
    navigate("/leaderboard");
  };

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="mx-auto h-screen flex-col items-center">
      <h1 className="text-6xl">Your final score: </h1>
      <p className="text-4xl font-bold">{finalScore}</p>
      <div className="flex">
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
  );
};
