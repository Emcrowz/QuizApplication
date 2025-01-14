import { useNavigate } from 'react-router-dom';
import { ParticipantModel } from '../types/ParticipantModel';

export const Score: React.FC<ParticipantModel> = ({ email, name, score, participationDate }) => {
    const navigate = useNavigate();

    const handleSubmitResults = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const newParticipant: ParticipantModel = {
            name: name,
            email: email,
            score: score,
            participationDate: participationDate
        };

        fetch('https://localhost:7219/participants', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newParticipant)
        })
        .then(res => res.json())
        .then(data => {
            console.log('Participant submitted successfully:', data);
        })
        .catch(error => {
            console.error('Error submitting participant:', error);
        });

        navigate('/leaderboard');
    }

    const handleNavigateToLeaderboard = () => {
        navigate('/leaderboard');
    }

    const handleNavigateToStart = () => {
        navigate('/');
    }

    return (
        <div>
            <h1>Your final score: </h1>
            <p>{score}</p>
            <p>Do you want to submit your result to leaderboard?</p>
            <form onSubmit={handleSubmitResults}>
                <button type="submit">Submit result to leaderboard</button>
            </form>
            <button type="button" onClick={handleNavigateToLeaderboard}>Check leaderboard without submitting</button>
            <button type="button" onClick={() => { window.location.reload(); handleNavigateToStart(); }}>Start again</button>
        </div>
    );
}