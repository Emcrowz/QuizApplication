import { useNavigate } from "react-router-dom";
import { Participant } from "../../Models/Participant";
import { API_ROUTE } from "../../Constants/RoutesAndPaths";
import React, { useState, useEffect } from "react";
import { Loading } from "../Common/Loading";

const participantApiPostReq = async (participant: Participant): Promise<number> => {
    let score = 0;

    try {
        const res = await fetch(API_ROUTE.PARTICIPANT_POST, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(participant),
        });
        const data = await res.json();
        score = data;
    } catch (error) {
        console.error("Error submitting participant:", error);
    }

    return score;
}

export const Score: React.FC<Participant> = ({
  email,
  name,
  participationDate,
  finalAnswers,
}) => {
  const navigate = useNavigate();
    const [score, setScore] = useState<number>(0);

    useEffect(() => {
        const fetchScore = async () => {
            const result = await participantApiPostReq({ name, email, participationDate, finalAnswers });
            setScore(result);
        };

        fetchScore();
    }, [score]);

  const handleNavigateToLeaderboard = () => {
    navigate("/leaderboard");
  };

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="mx-auto h-screen flex-col items-center">
          <h1 className="text-6xl">Your final score: </h1>
          <p className="text-4xl font-bold">{score === 0 ? (<Loading />) : score}</p>
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