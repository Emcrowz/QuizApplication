import { useEffect, useState } from 'react';
import './App.css';

interface Question {
    id: number;
    title: string;
    choises: string[];
    solution: string;
    points: number;
}

function App() {
    const [questions, setQuestions] = useState<Question[]>();

    useEffect(() => {
        populateQuestionData();
    }, []);

    const contents = questions === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table-striped table" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                </tr>
            </thead>
            <tbody>
                {questions.map(question =>
                    <tr key={question.id}>
                        <td>{question.title}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Quiz</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    async function populateQuestionData() {
        const response = await fetch('api/questions');
        if (response.ok) {
            const data = await response.json();
            setQuestions(data);
        }
    }
}

export default App;