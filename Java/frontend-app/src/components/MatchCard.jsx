import React from 'react';

const MatchCard = ({ match, onSelect }) => {
  return (
    <div className="match-card">
      <div className="match-header">
        <h3>{match.name}</h3>
        <span className="match-rating">{match.rating}</span>
      </div>
      <div className="match-details">
        <p>Thời gian: {match.time}</p>
        <p>Địa điểm: {match.location}</p>
      </div>
      <button onClick={() => onSelect(match)}>Chi tiết</button>
    </div>
  );
};

export default MatchCard;
