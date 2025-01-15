import { useNavigate } from "react-router-dom";
import { Participant } from "../../Models/Participant";
import { API_ROUTE } from "../../Constants/RoutesAndPaths";

export const Score: React.FC<Participant> = ({
  email,
  name,
  participationDate,
  finalAnswers,
}) => {
  const navigate = useNavigate();

  const handleSubmitResults = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const newParticipant: Participant = {
      name: name,
      email: email,
      participationDate: participationDate,
      finalAnswers: finalAnswers,
    };

    console.log(newParticipant);

    fetch(API_ROUTE.PARTICIPANTS, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newParticipant),
    })
      .then((res) => res.json())
      .then((data) => {
        console.log("Participant submitted successfully:", data);
      })
      .catch((error) => {
        console.error("Error submitting participant:", error);
      });

    navigate("/leaderboard");
  };

  const handleNavigateToLeaderboard = () => {
    navigate("/leaderboard");
  };

  const handleNavigateToStart = () => {
    navigate("/");
  };

  return (
    <div className="mx-auto h-screen flex-col items-center">
      <h1 className="text-6xl">Your final score: </h1>
      <p className="text-4xl font-bold">score</p>
      <p className=" text-4xl italic">
        Do you want to submit your result to leaderboard?
      </p>
      <form onSubmit={handleSubmitResults}>
        <button
          className="bg-green-500/65 rounded-xl p-4 hover:bg-green-400/85"
          type="submit"
        >
          Submit result to leaderboard
        </button>
      </form>
      <div className="flex">
        <button
          type="button"
          className="bg-amber-500/65 rounded-xl p-4 hover:bg-amber-400/85"
          onClick={handleNavigateToLeaderboard}
        >
          Check leaderboard without submitting
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
