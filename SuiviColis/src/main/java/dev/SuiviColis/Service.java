package dev.SuiviColis;


import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;

import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;

@Path("service")
public class Service {

	@Autowired
    private RepoColis repoColis;

	@GET
	@Path("/colis/{trackingNumber}")
	@Produces(MediaType.APPLICATION_JSON)
    public Colis getColis(@PathParam("trackingNumber") String trackingNumber) {
		Optional<Colis> c=repoColis.findById(trackingNumber);
		if(c.isPresent())
			return c.get();
		else
			return null;
    }
	
	
	@POST
	@Path("/colis")
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Colis addColis( Colis c) {
		return repoColis.save(c);
	}
	
	
}


