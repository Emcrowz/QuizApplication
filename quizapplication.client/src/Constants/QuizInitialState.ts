import { Participant } from "../Models/Participant";
import { QuizStatus } from "./QuizStatus";

const defaultParticipant: Participant = {
  name: "",
  email: "",
  participationDate: new Date(),
  finalAnswers: [],
  score: 0,
};

export const quizInitialState = {
  status: QuizStatus.Loading,
  participant: defaultParticipant,
  questions: [],
  currentAnswer: [],
  index: 0,
};
