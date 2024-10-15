package dev.ConsumerProject;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.core.MediaType;

@SpringBootApplication
public class ConsumerProjectApplication {

	public static void main(String[] args) {
		SpringApplication.run(ConsumerProjectApplication.class, args);
		Client client=ClientBuilder.newClient();
		String result=client.target("http://localhost:8081/service/colis/123").
				request(MediaType.APPLICATION_JSON).get(String.class);
		System.out.println(result);
	}

}
