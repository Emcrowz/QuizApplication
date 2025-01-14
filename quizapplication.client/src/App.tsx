import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Quiz } from "./Pages/Quiz";
import { Leaderboard } from "./Pages/Leaderboard";
import { NotFound } from "./Pages/NotFound";

export const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Quiz />} />
        <Route path="/leaderboard" element={<Leaderboard />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </BrowserRouter>
  );
};
