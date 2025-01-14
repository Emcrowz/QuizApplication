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
    <form>
          {question.type === QuestionType.Single ? (
        <div className="mb-4">
          {question.choises.map((choise) => (
            <div key={choise}>
              <input
                name="singleChoice"
                value={choise}
                type="radio"
                checked={selectedAnswers.includes(choise)}
                onChange={handleChange}
              />
              <label htmlFor={choise}>{choise}</label>
            </div>
          ))}
        </div>
      ) : question.type === QuestionType.Multiple ? (
        <div className="mb-4">
          {question.choises.map((choise) => (
            <div key={choise}>
              <input
                name="multipleChoice"
                value={choise}
                type="checkbox"
                checked={selectedAnswers.includes(choise)}
                onChange={handleChange}
              />
              <label htmlFor={choise}>{choise}</label>
            </div>
          ))}
        </div>
      ) : question.type === QuestionType.Typed ? (
        <div className="mb-4">
          <input
            type="text"
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
