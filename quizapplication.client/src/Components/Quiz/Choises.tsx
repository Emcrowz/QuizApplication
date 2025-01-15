import React, { useState, useEffect } from "react";
import { Question } from "../../Models/Question";
import { QuestionType } from "../../Constants/QuestionType";
import { ChoisesAnswerButton } from "./ChoisesAnswerButton";
import { QuizAction } from "../../Interfaces/QuizAction";

interface ChoisesProps {
  question: Question;
  dispatch: React.ActionDispatch<[action: QuizAction]>;
  index: number;
  numberOfQuestions: number;
}

export const Choises: React.FC<ChoisesProps> = ({
  question,
  dispatch,
  index,
  numberOfQuestions,
}) => {
  const [selectedAnswers, setSelectedAnswers] = useState<string[]>([]);

  useEffect(() => {
    setSelectedAnswers([]);
  }, [question]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const value = event.target.value;
    if (question.type === QuestionType.Single) {
      setSelectedAnswers([value]);
    }

    if (question.type === QuestionType.Multiple) {
      if (selectedAnswers.includes(value)) {
        setSelectedAnswers(
          selectedAnswers.filter((answer) => answer !== value)
        );
      } else {
        setSelectedAnswers([...selectedAnswers, value]);
      }
    }

    if (question.type === QuestionType.Typed) {
      setSelectedAnswers([value]);
    }
  };

  return (
    <form className="grid" onSubmit={(e) => e.preventDefault()}>
      {question.type === QuestionType.Single ? (
        <div className="mb-4">
          <p className="text-sm text-center italic">
            Select single correct answer
          </p>
          <ul className="grid grid-cols-4 max-w-screen-sm:grid-cols-2 mb-4">
            {question.choises.map((choise) => (
              <li key={choise}>
                <input
                  name="singleChoice"
                  value={choise}
                  type="radio"
                  checked={selectedAnswers.includes(choise)}
                  onChange={handleChange}
                />
                <label htmlFor={choise} className="ml-2 text-gray-700">
                  {choise}
                </label>
              </li>
            ))}
          </ul>
        </div>
      ) : question.type === QuestionType.Multiple ? (
        <div className="mb-4">
          <p className="text-sm text-center italic">
            Select multiple correct answers
          </p>
          <ul className="grid grid-cols-4 max-w-screen-sm:grid-cols-2 mb-4">
            {question.choises.map((choise) => (
              <li key={choise}>
                <input
                  name="multipleChoice"
                  value={choise}
                  type="checkbox"
                  checked={selectedAnswers.includes(choise)}
                  onChange={handleChange}
                />
                <label htmlFor={choise} className="ml-2 text-gray-700">
                  {choise}
                </label>
              </li>
            ))}
          </ul>
        </div>
      ) : question.type === QuestionType.Typed ? (
        <div className="mb-4 grid">
          <p className="text-sm text-center italic">Type in correct answer</p>
          <input
            className="border-2 rounded-xl p-4 text-center"
            type="text"
            placeholder="Your answer..."
            value={selectedAnswers[0] || ""}
            onChange={handleChange}
          />
        </div>
      ) : (
        <div>
          <p>Question Type Unrecognized.</p>
        </div>
      )}
      <ChoisesAnswerButton
        dispatch={dispatch}
        index={index}
        numberOfQuestions={numberOfQuestions}
        selectedAnswers={selectedAnswers}
      />
    </form>
  );
};
