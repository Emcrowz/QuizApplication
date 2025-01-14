import { Participant } from "../Models/Participant";
import { QuizStatus } from "./QuizStatus";

const defaultParticipant: Participant = {
  name: "",
  email: "",
  score: 0,
  participationDate: new Date(),
};

export const quizInitialState = {
  status: QuizStatus.Loading,
  participant: defaultParticipant,
  questions: [],
  answers: [],
  index: 0,
  points: 0,
};
