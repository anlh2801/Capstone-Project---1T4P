package com.odts.models;

public class TimeLine {
    private String status;
    private String time;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public TimeLine(String status, String time) {
        this.status = status;
        this.time = time;
    }

    public TimeLine() {
    }
}
