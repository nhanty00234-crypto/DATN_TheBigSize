import React, { useState } from 'react';
import Button from '../components/Button';

const BookingPage = () => {
  const [bookingData, setBookingData] = useState({
    matchId: '',
    date: '',
    time: '',
    location: ''
  });

  const handleSubmit = async (e) => {
    e.preventDefault();
    // Call API to create booking
  };

  return (
    <div className="booking-page">
      <h1>Đặt lịch thi đấu</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Chọn sân"
          value={bookingData.location}
          onChange={(e) => setBookingData({...bookingData, location: e.target.value})}
        />
        <input
          type="date"
          value={bookingData.date}
          onChange={(e) => setBookingData({...bookingData, date: e.target.value})}
        />
        <input
          type="time"
          value={bookingData.time}
          onChange={(e) => setBookingData({...bookingData, time: e.target.value})}
        />
        <Button type="submit" variant="primary">Đặt lịch</Button>
      </form>
    </div>
  );
};

export default BookingPage;
